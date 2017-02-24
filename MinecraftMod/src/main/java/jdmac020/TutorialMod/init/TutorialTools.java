package jdmac020.TutorialMod.init;

import jdmac020.TutorialMod.init.items.tools.TutorialAxe;
import jdmac020.TutorialMod.init.items.tools.TutorialHoe;
import jdmac020.TutorialMod.init.items.tools.TutorialPickaxe;
import jdmac020.TutorialMod.init.items.tools.TutorialShovel;
import jdmac020.TutorialMod.main.Reference;
import net.minecraft.client.Minecraft;
import net.minecraft.client.renderer.block.model.ModelResourceLocation;
import net.minecraft.creativetab.CreativeTabs;
import net.minecraft.item.Item;
import net.minecraft.util.ResourceLocation;
import net.minecraftforge.fml.common.registry.GameRegistry;

public class TutorialTools 
{
	public static Item RUBY_PICKAXE;
	public static Item RUBY_AXE;
	public static Item RUBY_SHOVEL;
	public static Item RUBY_HOE;
	
	public static Item COPPER_PICKAXE;
	public static Item COPPER_AXE;
	public static Item COPPER_SHOVEL;
	public static Item COPPER_HOE;
	
	public static void init()
	{
		RUBY_PICKAXE = new TutorialPickaxe(TutorialMaterials.RUBY, "ruby_pickaxe");
		RUBY_AXE = new TutorialAxe(TutorialMaterials.RUBY, "ruby_axe");
		RUBY_SHOVEL = new TutorialShovel(TutorialMaterials.RUBY, "ruby_shovel");
		RUBY_HOE = new TutorialHoe(TutorialMaterials.RUBY, "ruby_hoe");
		
		COPPER_PICKAXE = new TutorialPickaxe(TutorialMaterials.COPPER, "copper_pickaxe");
		COPPER_AXE = new TutorialAxe(TutorialMaterials.COPPER, "copper_axe");
		COPPER_SHOVEL = new TutorialShovel(TutorialMaterials.COPPER, "copper_shovel");
		COPPER_HOE = new TutorialHoe(TutorialMaterials.COPPER, "copper_hoe");
	}

	public static void register()
	{
		registerItem(RUBY_PICKAXE);
		registerItem(RUBY_AXE);
		registerItem(RUBY_SHOVEL);
		registerItem(RUBY_HOE);
		
		registerItem(COPPER_PICKAXE);
		registerItem(COPPER_AXE);
		registerItem(COPPER_SHOVEL);
		registerItem(COPPER_HOE);
	}
	
	public static void registerItem(Item item)
	{
		GameRegistry.register(item);
		
		Minecraft.getMinecraft().getRenderItem().getItemModelMesher()
		.register(item, 0, new ModelResourceLocation(Reference.MODID + ":" + item.getUnlocalizedName().substring(5), "inventory"));
	}
	
}
