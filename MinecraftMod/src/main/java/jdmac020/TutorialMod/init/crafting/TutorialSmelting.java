package jdmac020.TutorialMod.init.crafting;

import jdmac020.TutorialMod.init.TutorialBlocks;
import jdmac020.TutorialMod.init.TutorialItems;
import net.minecraft.init.Items;
import net.minecraft.item.ItemStack;
import net.minecraftforge.fml.common.registry.GameRegistry;

public class TutorialSmelting 
{

	public static void init() 
	{
		GameRegistry.addSmelting(TutorialBlocks.COPPER_ORE, new ItemStack(TutorialItems.COPPER_INGOT), 5);
		GameRegistry.addSmelting(TutorialBlocks.RUBY_ORE, new ItemStack(TutorialItems.RUBY), 5);
		GameRegistry.addSmelting(TutorialItems.COPPER_NUGGET, new ItemStack(TutorialItems.COPPER_COIN), 8);
		GameRegistry.addSmelting(TutorialItems.IRON_NUGGET, new ItemStack(TutorialItems.IRON_COIN), 5);
		GameRegistry.addSmelting(Items.GOLD_NUGGET, new ItemStack(TutorialItems.GOLD_COIN), 10);
		GameRegistry.addSmelting(TutorialItems.COPPER_COIN, new ItemStack(TutorialItems.COPPER_NUGGET), 3);
		GameRegistry.addSmelting(TutorialItems.GOLD_COIN, new ItemStack(Items.GOLD_NUGGET), 3);
		GameRegistry.addSmelting(TutorialItems.IRON_COIN, new ItemStack(TutorialItems.IRON_NUGGET), 3);
	}

}
