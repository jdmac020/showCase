package jdmac020.TutorialMod.init.crafting;

import jdmac020.TutorialMod.init.TutorialBlocks;
import jdmac020.TutorialMod.init.TutorialItems;
import jdmac020.TutorialMod.init.TutorialTools;
import net.minecraft.init.Items;
import net.minecraft.item.ItemStack;
import net.minecraftforge.fml.common.registry.GameRegistry;

public class TutorialRecipes 
{
	public static void init()
	{
		//Copper block
		GameRegistry.addRecipe(new ItemStack(TutorialBlocks.COPPER_BLOCK),
				new Object [] {
					"###",
					"###",
					"###",
					'#', TutorialItems.COPPER_INGOT
		});
		
		//Ruby block
		GameRegistry.addRecipe(new ItemStack(TutorialBlocks.RUBY_BLOCK),
				new Object [] {
					"###",
					"###",
					"###",
					'#', TutorialItems.RUBY
		});
				
		//Copper block to ingots
		GameRegistry.addShapelessRecipe(new ItemStack(TutorialItems.COPPER_INGOT, 9),
				new Object [] {
				TutorialBlocks.COPPER_BLOCK		
				});
		
		//Ruby block to rubies
		GameRegistry.addShapelessRecipe(new ItemStack(TutorialItems.RUBY, 9),
				new Object [] {
				TutorialBlocks.RUBY_BLOCK		
		});
		
		//Copper ingots to nuggets
		GameRegistry.addShapelessRecipe(new ItemStack(TutorialItems.COPPER_NUGGET, 9),
				new Object [] {
				TutorialItems.COPPER_INGOT		
		});
		
		//Iron ingots to nuggets
		GameRegistry.addShapelessRecipe(new ItemStack(TutorialItems.IRON_NUGGET, 9),
				new Object [] {
				Items.IRON_INGOT		
		});
		
		//Copper nuggets back to ingot
		GameRegistry.addRecipe(new ItemStack(TutorialItems.COPPER_INGOT),
				new Object [] {
					"###",
					"###",
					"###",
					'#', TutorialItems.COPPER_NUGGET
		});
		
		//Iron nuggets back to ingot
		GameRegistry.addRecipe(new ItemStack(Items.IRON_INGOT),
				new Object [] {
					"###",
					"###",
					"###",
					'#', TutorialItems.IRON_NUGGET
		});
		
		//Copper axe
		GameRegistry.addShapedRecipe(new ItemStack(TutorialTools.COPPER_AXE, 1),
			"CC ",
			"CS ",
			" S ",
			'C', TutorialItems.COPPER_INGOT, 'S', Items.STICK
		);
		
		//Copper pickaxe
		GameRegistry.addShapedRecipe(new ItemStack(TutorialTools.COPPER_PICKAXE, 1),
				"CCC",
				" S ",
				" S ",
				'C', TutorialItems.COPPER_INGOT, 'S', Items.STICK
		);
		
		//Copper shovel
		GameRegistry.addShapedRecipe(new ItemStack(TutorialTools.COPPER_SHOVEL, 1),
				" C ",
				" S ",
				" S ",
				'C', TutorialItems.COPPER_INGOT, 'S', Items.STICK
		);
		
		//Copper hoe
		GameRegistry.addShapedRecipe(new ItemStack(TutorialTools.COPPER_HOE, 1),
				"CC ",
				" S ",
				" S ",
				'C', TutorialItems.COPPER_INGOT, 'S', Items.STICK
		);
		
		//Ruby axe
		GameRegistry.addShapedRecipe(new ItemStack(TutorialTools.RUBY_AXE, 1),
				"RR ",
				"RS ",
				" S ",
				'R', TutorialItems.RUBY, 'S', Items.STICK
		);
		
		//Ruby pick
		GameRegistry.addShapedRecipe(new ItemStack(TutorialTools.RUBY_PICKAXE, 1),
				"RRR",
				" S ",
				" S ",
				'R', TutorialItems.RUBY, 'S', Items.STICK
		);
		
		//Ruby shovel
		GameRegistry.addShapedRecipe(new ItemStack(TutorialTools.RUBY_AXE, 1),
				" R ",
				" S ",
				" S ",
				'R', TutorialItems.RUBY, 'S', Items.STICK
		);
		
		//Ruby hoe
		GameRegistry.addShapedRecipe(new ItemStack(TutorialTools.RUBY_HOE, 1),
				"RR ",
				" S ",
				" S ",
				'R', TutorialItems.RUBY, 'S', Items.STICK
		);
	}
}
