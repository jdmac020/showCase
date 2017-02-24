package jdmac020.TutorialMod.init;

import jdmac020.TutorialMod.init.items.weapons.TutorialSwords;
import jdmac020.TutorialMod.main.Reference;
import net.minecraft.client.Minecraft;
import net.minecraft.client.renderer.block.model.ModelResourceLocation;
import net.minecraft.creativetab.CreativeTabs;
import net.minecraft.item.Item;
import net.minecraft.util.ResourceLocation;
import net.minecraftforge.fml.common.registry.GameRegistry;

public class TutorialWeapons 
{
	public static Item RUBY_SWORD;
	public static Item COPPER_SWORD;
	
	
	public static void init()
	{
		RUBY_SWORD = new TutorialSwords(TutorialMaterials.RUBY, "ruby_sword");
		COPPER_SWORD = new TutorialSwords(TutorialMaterials.COPPER, "copper_sword");
	}
	
	public static void register()
	{
		registerItem(RUBY_SWORD);
		registerItem(COPPER_SWORD);
	
	}
	
	public static void registerItem(Item item)
	{
		GameRegistry.register(item);
		
		Minecraft.getMinecraft().getRenderItem().getItemModelMesher()
		.register(item, 0, new ModelResourceLocation(Reference.MODID + ":" + item.getUnlocalizedName().substring(5), "inventory"));
	}
	
}
